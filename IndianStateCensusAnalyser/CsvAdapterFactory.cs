﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalyser;

namespace IndianStateCensusAnalyser
{
    public class CsvAdapterFactory
    {
        
        public List<FullCensusData> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string headers)
        {
            try
            {
                //Checking the country 
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        {
                            return new IndianCensusAdapter().LoadCensusData(csvFilePath, headers);
                        }
                    default:
                        {
                            throw new CensusAnalyserException("NO SUCH COUNTRY", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                        }
                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}
