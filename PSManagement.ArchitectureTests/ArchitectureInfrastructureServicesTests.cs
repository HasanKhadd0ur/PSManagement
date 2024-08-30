using NetArchTest.Rules;
using FluentAssertions;
using Xunit;

namespace PSManagement.ArchitectureTests
{
     public class ArchitectureInfrastrutureServicesTests : ArchitectureTest
        {
        [Fact]
        public void Services_Should_Not_DependOnOtherProject()
        {

            // Arrange
            var otherProject = new[]
            {
                PresentationNamespace,
                ApiNamespace,
                DataNamespace
                
            };

            // Act
            var result = Types
                .InAssembly(PSManagement.Infrastructure.Services.AssemblyReference.Assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }
    }

}
