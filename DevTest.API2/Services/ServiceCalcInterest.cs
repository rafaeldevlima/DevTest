using DevTest.Shared.Commands;
using DevTest.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.API2.Services
{
    public class ServiceCalcInterest
    {
        private ServiceInterestRate _serviceInterestRate;

        public ServiceCalcInterest(ServiceInterestRate service)
        {
            _serviceInterestRate = service;
        }

        public async Task<InterestCalcResultDTO> CalcInterest(InterestCommand command)
        {
            InterestCalcResultDTO interestCalcResult = new InterestCalcResultDTO();

            var interestRate =  await _serviceInterestRate.GetInterestRate();

            if(interestRate==null)
            {
                interestCalcResult.Success = false;
                interestCalcResult.FinalValue = 0;
                interestCalcResult.Messages = new List<string>();
                interestCalcResult.Messages.Add("Opss.. Somenthing wrong when get the interest rate.");
                return interestCalcResult;

            }

            double dblFinalValue = Math.Pow(Convert.ToDouble(command.InitialValue * (1 + interestRate.rate)), Convert.ToDouble(command.Time));


            interestCalcResult.Success = true;
            interestCalcResult.FinalValue = (decimal)(Math.Truncate(dblFinalValue * 100) / 100);
            return interestCalcResult;

        }
    }
}
