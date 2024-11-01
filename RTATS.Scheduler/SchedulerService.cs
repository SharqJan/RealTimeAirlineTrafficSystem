using RTATS.Application.Interfaces;
using RTATS.Core.ViewModel;
using System.Text.Json;

namespace RTATS.Scheduler;
public class SchedulerService : BackgroundService
    {
        private readonly ILogger<SchedulerService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
    public SchedulerService(ILogger<SchedulerService> logger, IConfiguration configuration, IUnitOfWork unitOfWork)
   
    {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = configuration;
        
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
       
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                var url = _configuration.GetSection("Url").Value;
                
                using HttpClient client = new HttpClient();
                var responseBody = await client.GetStringAsync(url, stoppingToken);

                // Console.WriteLine(responseBody);
                // using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<AirlineTrafficSystemViewModel>(responseBody);

                //var obj = new RealtimeAirlineTrafficSystemRepository(APISettings.Value.CommandTimeOut, APISettings.Value.ConnectionSMS);

                var dataList = await _unitOfWork.RealtimeAirlineTrafficSystemRepository.AddRealTimeAirlineTrafficSystem(stoppingToken, result.pagination);

                if (result.data.Count > 0)
                {
                    for (int i = 0; i < result.data.Count; i++)
                        Console.WriteLine(result.data[i].flight_date);
                }
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}. Good luck next round!");
            }
        }
    }
}
