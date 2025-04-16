using server.Classes;
using server.Enums;

namespace server;
using Xunit;
public class Xunit_test
{
    public class IssueStateTests
    {
        [Fact]
        public void ChangeIssueState_ToClosed_ShouldUpdateState()
        {
            //setup
            var issue = new Issue(
                Guid.NewGuid(), "DemoAB", "M@mail.com", "SUPPORT", 
                IssueState.OPEN, "Problem med tjänst", DateTime.Now, DateTime.Now);

            // Act
            issue.State = IssueState.CLOSED;

            // Assert
            Assert.Equal(IssueState.CLOSED, issue.State);
        }
    }

    public class IssueValidationTests
    {
        [Fact]
        public void CreateIssue_WithEmptyTitle_ShouldFailValidation()
        {
            // Arrange
            var issue = new Issue(
                id: Guid.NewGuid(),
                companyName: "Testbolag",
                customerEmail: "test@test.se",
                subject: "Teknik",
                state: IssueState.OPEN,
                title: "",
                created: DateTime.Now,
                latest: DateTime.Now
            );

            // Act
            var isValid = !string.IsNullOrWhiteSpace(issue.Title);

            // Assert
            Assert.False(isValid);
        }
    }

    public class MessageTests
    {
        [Fact]
        public void Createmessage_withValidSender_shouldBeSuccessfull()
        {
            //setup
            var validSenders = new[] {"CUSTOMER", "SUPPORT"};
            var message = new Message("Hej, Jag har fått problem.", "CUSTOMER", "testuser", DateTime.Now);
            
            //Agerande
            var isValidSender = validSenders.Contains(message.Sender.ToUpper());
            
            //Assert
            Assert.True(isValidSender);
        }
    }
    [Fact]
    public void GuestUser_shouldNotHaveAdminAccess()
    {
        //setup
        var user = new User(1, "guestuser", Role.GUEST, 1, "TestAB");
        
        // assert
        Assert.DoesNotContain(user.Role, new[] { Role.ADMIN, Role.USER });
    }


}