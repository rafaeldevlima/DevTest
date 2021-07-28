using DevTest.Model;
using DevTest.Shared.Commands;
using DevTest.Shared.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Services
{
    public class ServicesInterestCalc
    {
        public async Task<InterestCalcResultDTO> getInterestCalc(InterestCommand _interestCommand)
        {
            InterestCalcResultDTO interestCalcResultDTO = new InterestCalcResultDTO();

            try
            {
               
                var client = new HttpClient();

                string apiURL = EndPoints.getUrlAPICalcInterest;

                UriBuilder builder = new UriBuilder(apiURL);

                string postBody = JsonConvert.SerializeObject(_interestCommand);

                using var response = await client.PostAsync(apiURL, new StringContent(postBody, System.Text.Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = response.ReasonPhrase;
                    Console.WriteLine($"Erro ! {errorMessage}");
        
                    interestCalcResultDTO.Success = false;
                    interestCalcResultDTO.FinalValue = 0;
                    interestCalcResultDTO.Messages = new List<string>();
                    interestCalcResultDTO.Messages.Add("Oops...Something get wrong..Try later..");

                    return interestCalcResultDTO;

                }

                var result = await response.Content.ReadAsStringAsync();

                if (result != null)
                {
                    interestCalcResultDTO = JsonConvert.DeserializeObject<InterestCalcResultDTO>(result);
                    interestCalcResultDTO.Success = true;
                    return interestCalcResultDTO;
                }
                else
                {
                    interestCalcResultDTO.Success = false;
                    return interestCalcResultDTO;
                }

            }
            catch (Exception )
            {
                interestCalcResultDTO = new InterestCalcResultDTO();

                interestCalcResultDTO.Success = false;
                interestCalcResultDTO.FinalValue = 0;
                interestCalcResultDTO.Messages = new List<string>();
                interestCalcResultDTO.Messages.Add("Oops...Something get wrong..Try later..");

                return interestCalcResultDTO;

            }
        }

    }
}
