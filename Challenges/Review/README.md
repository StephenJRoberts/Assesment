# Develop Challenge

This challenge is to review the code in the event logger application.

# Requirements

Review the code in the Logger.cs class and suggest any ammendments you feel should be made to improve the code. Fill in your suggestions and reasoning below.

| Line(s) | Suggested Change | Reasoning |
|---------|------------------|-----------|
|         |                  |           |

When I got m this .Net 3.1 Application it did not work initially as EventSourceB.cs was empty, I therefore made it a copy of EventSourceA but changed the dispose function.
I also changed the logger dispose function to run the dispose function of the event source, which would in turn run the event occurred function. Although after that the output in the console was “Event Occured” followed by 0 on the next line.
