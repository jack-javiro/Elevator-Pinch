You will need .Net 9 to run the console app.

Instructions to test: 

Just run it and it will do 1 test scenario at a time.

Hit a key to continues to the next test.

A few very basic unit tests are there to run as well.

-------------------------------------------------

Disclaimer:

This is a fairly complicated task to complete in 4 hours. (I spent 3-4 hours on this)

In that time I tried to cover the 4 scenarios. (a bit buggy but not to bad in the time given.)

The program.cs contains too much logic.

The Step() methods is to big and yet too simple, needs refactoring to be more robust and split in to separate methods.

Even thought there are a few unit test, they are too simple and do not have great coverage.

Also, having Task.Delay through the code is something I would never normally do.
