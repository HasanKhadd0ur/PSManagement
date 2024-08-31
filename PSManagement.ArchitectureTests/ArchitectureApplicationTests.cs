using NetArchTest.Rules;
using FluentAssertions;
using Xunit;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Events;
using PSManagement.SharedKernel.DomainEvents;

namespace PSManagement.ArchitectureTests
{
    public partial class ArchitectureApplicationTests : ArchitectureTest
    {

        #region Events Handler Naming Convention 
        [Fact]
        public void EventHandler_ShouldHave_NameEndingWith_EventHandler()
        {
            var result = Types.InAssembly(PSManagement.Application.AssemblyReference.Assembly)
                .That()
                .ImplementInterface(typeof(IDomainEventHandler<>))
                .Should()
                .HaveNameEndingWith("EventHandler")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }

        #endregion Events Handler Naming Convention

        #region Command Handler Naming Convention

        [Fact]
        public void CommandHandlers_ShouldHave_NameEndingWith_CommandHandler()
        {
            var result = Types.InAssembly(PSManagement.Application.AssemblyReference.Assembly)
                .That()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Should()
                .HaveNameEndingWith("CommandHandler")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }

        #endregion Command Handler Naming Convention

        #region Command Naming Convention

        [Fact]
        public void Commands_ShouldHave_NameEndingWith_Command()
        {
            var result = Types.InAssembly(PSManagement.Application.AssemblyReference.Assembly)
                .That()
                .ImplementInterface(typeof(ICommand<>))
                .Should()
                .HaveNameEndingWith("Command")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }

        #endregion Command Naming Convention


        #region Query Handler Naming Convention

        [Fact]
        public void QueryHandlers_ShouldHave_NameEndingWith_QueryHandler()
        {
            var result = Types.InAssembly(PSManagement.Application.AssemblyReference.Assembly)
                .That()
                .ImplementInterface(typeof(IQueryHandler<,>))
                .Should()
                .HaveNameEndingWith("QueryHandler")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }


        #endregion Query Handler Convention


        #region Query  Naming Convention

        [Fact]
        public void Queries_ShouldHave_NameEndingWith_Query()
        {
            var result = Types.InAssembly(PSManagement.Application.AssemblyReference.Assembly)
                .That()
                .ImplementInterface(typeof(IQuery<>))
                .Should()
                .HaveNameEndingWith("Query")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }


        #endregion Query  Convention


        #region Dummy Test 
        //[Fact]
        //public void Application_Should_Have_DependOnDomain()
        //{

        //    // Arrange
        //    var otherProject = new[]
        //    {
        //        DomainNamespace
        //    };

        //    // Act
        //    var result = Types
        //        .InAssembly(Application.AssemblyReference.Assembly)
        //        .That()
        //        .HaveNameEndingWith("Handler")
        //        .Should()
        //        .HaveDependencyOnAll(otherProject)
        //        .GetResult();

        //    // Assert
        //    result.IsSuccessful.Should().BeTrue();
        //}
        #endregion Dummy Test 
    }

}
