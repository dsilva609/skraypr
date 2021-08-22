using FluentAssertions;
using Skraypr.Features.Enums;
using Skraypr.Features.Providers;
using Skraypr.Test.Features.Pages;
using Xunit;

namespace Skraypr.Test.Features.Providers
{
    public class TestProviderTests
    {
        private readonly TestProvider _provider;

        public TestProviderTests()
        {
            var seleniumProvider = new SeleniumProvider();

            var testPage = new TestPage("/feed/explore");

            _provider = new TestProvider("https://youtube.com", new[] { testPage }, seleniumProvider);
        }

        [Fact]
        public void Provider_Navigates_To_Page()
        {
            var result = _provider.Execute();

            result.ExecutionStatus.Should().Be(ProviderStatusEnum.Successful);
        }
    }
}