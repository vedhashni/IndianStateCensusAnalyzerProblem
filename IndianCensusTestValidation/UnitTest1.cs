﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IndianStateCensusAnalyser;
using System.Collections.Generic;


namespace IndianCensusTestValidation
{
    [TestClass]
    public class UnitTest1
    {
        //Initializing the path 
        string stateCensusDataPath = @"C:\Users\ven\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusData.csv";
        string wrongstateCensusDataPath = @"C:\Users\ven\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusD.csv";
        string wrongstateCensusDataCSVPath = @"C:\Users\ven\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusData.txt";
        string wrongDelimiterstateCensusDataCSVPath = @"C:\Users\ven\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongDelimiterIndiaStateCensusData.csv";
        string wrongHeaderstateCensusDataCSVPath = @"C:\Users\ven\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongHeaderIndiaStateCensusData.csv";
        CsvAdapterFactory csv = null;
        List<FullCensusData> totalRecords;
        List<FullCensusData> stateRecords;

        [TestInitialize]
        //Initialize the record value
        public void Setup()
        {

            csv = new CsvAdapterFactory();
            totalRecords = new List<FullCensusData>();
            stateRecords = new List<FullCensusData>();
        }
        /// <summary>
        /// UC1-TC1.1--->Returns the count of records present in IndianstateCensusData
        /// </summary>
        [TestMethod]
        public void Given_State_Census_Return_CountOf_Records()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusDataPath, "State,Population,AreaInSqKm,Density");
            Assert.AreEqual(9, stateRecords.Count);

        }
        /// <summary>
        /// UC1-TC1.2--->Handle the file not found custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.3--->Handle the wrong file extension path using custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Extension_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.4--->Wrong delimiter in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_Delimiter_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.5--->Wrong headers in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]

        public void Incorrect_Headers_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, customEx.exception);
        }
    }
}
