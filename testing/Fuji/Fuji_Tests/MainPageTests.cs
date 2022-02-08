using NUnit.Framework;
using Fuji.Models;

namespace Fuji_Tests;

public class MainPageTests
{
    private static MainPageVM MakeValidMainPageVM()
    {
        return new MainPageVM
        {
            FirstName = "Julie"
        };
    }

    [SetUp]
    public void Setup()
    {
    }

    /*
        Examples of tests that use the custom ModelValidator to run through the DataAnnotations present
        in a model(-ish) class, but for a model that isn't auto-generated by Entity Framework.  Use for view models
        or any model class you're using for form validation.
    */

    [Test]
    public void MainPageVM_HasFirstName_isValid()
    {
        // Arrange
        MainPageVM vm = MakeValidMainPageVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void MainPageVM_MissingFirstName_isNotValid()
    {
        // Arrange
        MainPageVM vm = new MainPageVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void MainPageVM_MissingFirstName_TestBySpecificValidationError_isNotValid()
    {
        // Arrange
        MainPageVM vm = new MainPageVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert

        Assert.That(mv.ContainsFailureFor("FirstName"), Is.True);
    }


}