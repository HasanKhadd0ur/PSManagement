using NetArchTest.Rules;
using FluentAssertions;
using Xunit;

namespace PSManagement.ArchitectureTests
{
    public partial class ArchitectureDomainTests : ArchitectureTest
    {

        [Fact]
        public void Domain_Should_Not_DependOnOtherProject()
        {

            // Arrange
            var otherProject = new[]
            {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            ApiNamespace
        };

            // Act
            var result = Types
                .InAssembly(PSManagement.Domain.AssemblyReference.Assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            // Assert
           result.IsSuccessful.Should().BeTrue();
        }
    }
}
