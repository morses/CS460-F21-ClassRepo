# ID 4
<hr>

## Title
*As an administrator of the site I want an admin page that only I can access after logging in*

## Description
We want to add the ability for users to log in to the site.  This user story is just building the initial capability -- we're not yet building features for those logged in users.  But we do need to deliver value and demo this in working order, so we'll build the beginning of an administration feature: an administration dashboard.

Add authentication and authorization to the application using ASP.NET Core Identity, following the 2 database architecture described in class.  Then, seed a single admin username and password with the role of admin.  Finally, build a page at `/admin/index` or `/admin` that displays a simple welcome title for administrators, and make it so only someone logged in with the admin role can access the page.  All other users, logged in or not, receive a Not Authorized, or are redirected to the login page (this is the default I think).

## Acceptance Criteria
No .feature file for this one

    Given I am the administrator
    And I am logged in
    When I navigate to '/admin'
    Then I will see a welcome message

    Given I am not the administrator
    And I am logged in
    When I navigate to '/admin'
    Then I will not be able to see the welcome message

    Given I am a visitor and have no account
    When I navigate to '/admin'
    Then I will not be able to see the welcome message

    Given I am a visitor
    And I am on the Register page
    When I register a new account
    Then I can log in using that account
    And I can see my email or username in the navbar that alerts me to the fact I am logged in

## Assumptions/Preconditions

## Dependencies

## Effort Points

## Owner

## Git Feature Branch
TFA-US-4-authentication

## Modeling and Other Documents

## Tasks
1. ...
2. ...