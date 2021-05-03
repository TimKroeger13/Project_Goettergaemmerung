using NSubstitute;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Unittests.Components.CardInformationGetter
{
    public class CsvCardInformationTests
    {
        private static CsvCardInformation CreateCsvCardInformation()
        {
            return new CsvCardInformation();
        }

        [Fact]
        public void GetCardInformation_StateUnderTest_ExpectedBehavior()
        {
            var csvCardInformation = CreateCsvCardInformation();
            var result = csvCardInformation.GetCardInformation("");
            Assert.True(result.Count() == 483);
        }
    }
}
