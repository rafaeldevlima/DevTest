using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevTest.Shared.DTOs;
using Newtonsoft.Json;

namespace DevTest.API2.Services
{
    public class ServiceInterestRate
    {
        public async Task<InterestRateDTO> GetInterestRate()
        {
            InterestRateDTO interestRateDTO = new InterestRateDTO();

            try
            {
                //string apiURL = "https://localhost:44337/Api/interest-rate";
                string apiURL = "http://localhost:25684/Api/interest-rate";

                UriBuilder builder = new UriBuilder(apiURL);

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(builder.Uri).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return interestRateDTO;
                    }

                    var result = await response.Content.ReadAsStringAsync();

                    if (result != null)
                    {
                        interestRateDTO = JsonConvert.DeserializeObject<InterestRateDTO>(result);
                        
                    }

                    return interestRateDTO;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

    }
}
