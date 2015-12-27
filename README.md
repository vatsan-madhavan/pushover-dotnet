pushover-dotnet
===============

.NET Wrapper around [Pushover.net](http://www.pushover.net).

## Quick start

Get an [API key](https://pushover.net/apps/build).

    var client = new PushoverClient("api-key");
    client.Push(new PushoverMessageBase
    {
        User = "user-key",
        Message = "Hello from Pushover!"
    });

## Errors

    try 
    {
        var client = new PushoverClient("api-key");
        client.Push(new PushoverMessageBase
        {
            User = "user-key",
            Message = "Hello from Pushover!"
        });   
    }
    catch(ArgumentException ae)
    {
        // Thrown if you pass in a null message or null/empty user key
    }
    catch(PushoverException pe)
    {
        // Thrown if there is a problem sending the message
        Logger.Error(pe.Message);
    }

## Additional message properties

    var client = new PushoverClient("api-key");
    client.Push(new PushoverMessageBase
    {
        User = "user-key",
        Message = "Hello from Pushover!",
        Title = "Test Message",
        Url = "http://pushover.net",
        UrlTitle = "Pushover",
        Priority = MessagePriority.High,
        Timestamp = DateTime.Now,
        Expiration = 3600, //seconds - for Emergency priority
        Retry = 30 //seconds - for Emergency priority
    });
    
## Nlog Target
Add a Pushover Target to your LoggingConfiguration. (Or use nlog.config syntax)

    var logConfig = new LoggingConfiguration();
    var target = new PushoverTarget()
    {
        AppToken = "YOUR PUSHOVER APP TOKEN. ref: https://pushover.net ",
        UserOrGroupKey = "YOUR PUSHOVER USER KEY. ref: https://pushover.net "
    };
    logConfig.AddTarget(target);
    logConfig.LoggingRules.Add(new LoggingRule("*",LogLevel.Error, target));
    LogManager.Configuration = logConfig;
    LogManager.ReconfigExistingLoggers();
    logger = LogManager.GetCurrentClassLogger();
    
Now, logs with ERROR or FATAL levels will be sent to your Pushover account:

    logger.Error("Error test");
    logger.Fatal("Fatal test");