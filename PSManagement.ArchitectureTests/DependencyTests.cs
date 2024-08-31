using NetArchTest.Rules;
using FluentAssertions;
using Xunit;

namespace PSManagement.ArchitectureTests
{
    public class DependencyTests : ArchitectureTest
    {
        #region Presentation Layer 

        [Fact]
        public void Presentation_Should_Not_DependOnOtherProjectExceptApplicationAndContracts()
        {

            // Arrange
            var otherProject = new[]
            {
                InfrastructureNamespace,
                DataNamespace,
                DomainNamespace
            };


            // Act
            var result = Types
                .InAssembly(Presentation.AssemblyReference.Assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }

        #endregion Presentation Layer 

        #region Application Layer 
        [Fact]
        public void Application_Should_Not_DependOnOtherProjectExceptDmain()
        {

            // Arrange
            var otherProject = new[]
            {
            InfrastructureNamespace,
            PresentationNamespace,
            DataNamespace,
            ApiNamespace
        };

            // Act
            var result = Types
                .InAssembly(Application.AssemblyReference.Assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }

        #endregion Application Layer 

        #region Domain Layer 
        [Fact]
        public void Domain_Should_Not_DependOnOtherProjectExceptSharedKernel()
        {

            // Arrange
            var otherProject = new[]
            {
            ApplicationNamespace,
            InfrastructureNamespace,
            DataNamespace,
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

        #endregion Domain Laye

        #region PersistenceLayer Layer 
        [Fact]
        public void Persistence_Should_Not_DependOnOtherProjectExceptDomain()
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
                .InAssembly(PSManagement.Infrastructure.Persistence.AssemblyReference.Assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }


        #endregion Persistence Layer 

        #region Services Layer 

        [Fact]
        public void Services_Should_Not_DependOnOtherProjectExceptApplication()
        {

            // Arrange
            var otherProject = new[]
            {
                PresentationNamespace,
                ApiNamespace,
                DataNamespace,
                DomainNamespace

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

        #endregion Services Layer 

    }

}
