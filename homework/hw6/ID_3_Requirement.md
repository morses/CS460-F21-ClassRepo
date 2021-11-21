# ID 3
<hr>

## Title

*As a user I want to view all track meet data for any athlete so I can know the data has been recorded in the system, see what team the athlete is on, and easily view past results.*

## Description

This user story is about making it easy to find an athlete and view information about them including all their race data.  Stakeholders have indicated they see this site as having a team-based focus.  This means we think about teams first and then their athletes and coach.  This gives us some guidance about how to find an athlete.  Rather than a search functionality we'll first start with the team and then drill down to the athlete.

We'll want a navbar item called **Teams** that will take the user to a page at `/teams` or `/teams/index`.  On this page the user will see all the teams currently in the system.  Ultimately they indicated they want images of each teams mascot together with their names but since we don't have that yet we'll stick with names.  They should be stacked vertically in a sidebar since there aren't very many of them.  (If they later want large mascot images we might have to put them in a grid of tiles, but that's nothing to worry about now.)

The user can click on a team and they'll then see a list of all the athletes on that team.  Clicking on an athlete takes the user to a page where the desired output can be found that contains all that athlete's race data.  

### Details:

1. Sidebar with team names: display full team name, sorted alphabetically
2. When clicked (a GET request so the back button will work; or use Javascript), display Team Name and Coaches full name at the top of the main area, plus the list of athletes, each a link.  If the team is new or the coach hasn't yet provided results for athletes and there are no athletes on the team, then display a simple message stating that.
3. The athlete link should be their full name, sorted alphabetically by last name.  Link is to the athlete's main page at `/athlete/id` where `id` is the identifying value for that athlete.  Also acceptable is `/athlete/full_name` where spaces have been converted to underscores.  We think in a later story this will become the athlete's profile page.
4. Race data is displayed in a table.  Columns to display (in order left to right): Event type (i.e. 100, 200, ...), Race time in seconds (with 2 decimal places), Meet date, Meet location.  These should be sorted first by Event type as a race distance, then by date, so that all 100's are together, then all 100 hh, then all 110 hh, then 200's etc. and within each event type the races are shown by date with the oldest at the top and the newest appearing lower, i.e. chronologically by increasing date. (Do not display hours, minutes or seconds.)  Table should have headers in bold or larger font to offset them and make them look like column headers.
5. Clicking the back button at this point should take the user back to the teams page where all the athletes on the current team are still displayed.  This will make it easy for the user to explore results for each athlete on the team since they won't have to select the team again.

See the quick UI mockup in the docs below.

## Acceptance Criteria
Please see the associated .feature file

## Assumptions/Preconditions
System has all the data associated with the racetimes.csv and racetimes2.csv files as well as seed data from earlier stories.

## Dependencies
ID 2

## Effort Points

## Owner

## Git Feature Branch
TFA-US-3-athlete-data

## Modeling and Other Documents

Teams page mockup: [Teams Page](TeamsPage.png "Mockup of the Team and Athlete selection page")

Athlete page mockup:[Athlete Page](AthletePage.png  "Mockup of the Athlete page")

## Tasks
1. ...
2. ...