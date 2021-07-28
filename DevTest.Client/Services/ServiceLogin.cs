using DevTest.Model;
using DevTest.Shared.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevTest.Services
{
    public class ServiceLogin
    {
     
        public async Task<ResultDTO> LoginAsync(LoginDTO loginDTO)
        {
            ResultDTO resultLogin = new ResultDTO();
            
            var client = new HttpClient();

            string apiURL = EndPoints.getUrlAPILogin;

            UriBuilder builder = new UriBuilder(apiURL);

            string postBody = JsonConvert.SerializeObject(loginDTO);

            using var response = await client.PostAsync(apiURL, new StringContent(postBody, System.Text.Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = response.ReasonPhrase;
                Console.WriteLine($"Erro ! {errorMessage}");

                resultLogin.Success = false;
                resultLogin.Messages = new List<string>();
                resultLogin.Messages.Add("Oops...Login Failed..Try later..");

                return resultLogin;

            }

            var result = await response.Content.ReadAsStringAsync();

            if (result != null)
            {
                LoginTokenDTO loginTokenDTO = JsonConvert.DeserializeObject<LoginTokenDTO>(result);
                resultLogin.token = loginTokenDTO.token;
                resultLogin.Success = true;
                
                return resultLogin;
            }
            else
            {
                resultLogin.Success = false;
                resultLogin.Messages.Add("Oops...Login Failed..Try later..");
                return resultLogin;
            }
            
        }
    }
}
