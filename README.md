# WebApiSerilog
Tests for performance of serilog for linux hosting. 

#Conclusion

Async logging is faster especially for log long mesasges to file. But for action log we still pay halph of time for logging.

# How to web.api was generated:

dotnet new webapi --no-https --framework netcoreapp3.1
dotnet add package Serilog.AspNetCore -v 3.2.0

Example of logging middleware:

https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/

# Testing tool gobench:

go get github.com/valyala/fasthttp
git clone https://github.com/cmpxchg16/gobench.git
cd gobench

go run gobench.go  -u http://localhost:5000/WeatherForecast  -k=true -c 500 -t 10


# Results:

RequestResponseLoggingMiddleware:

a) Serilog.Sinks.File

Dispatching 500 clients
Waiting for results...

Requests:                           159991 hits
Successful requests:                159991 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            15999 hits/sec
Read throughput:                  10579336 bytes/sec
Write throughput:                  1620959 bytes/sec
Test time:                              10 sec
Log file size: 				99.4mb

b) Serilog.Sinks.Async

Dispatching 500 clients
Waiting for results...

Requests:                           255154 hits
Successful requests:                255154 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            25515 hits/sec
Read throughput:                  16872211 bytes/sec
Write throughput:                  2582105 bytes/sec
Test time:                              10 sec
Log file size: 				158.3mb
 	
RequestLoggingMiddleware:

a) Serilog.Sink.File

Dispatching 500 clients
Waiting for results...

Requests:                           277529 hits
Successful requests:                277529 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            27752 hits/sec
Read throughput:                  18351792 bytes/sec
Write throughput:                  2808092 bytes/sec
Test time:                              10 sec
Log file size: 				19.9mb

b) Serilog.Sink.Async

Dispatching 500 clients
Waiting for results...

Requests:                           295942 hits
Successful requests:                295942 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            29594 hits/sec
Read throughput:                  19569022 bytes/sec
Write throughput:                  2994064 bytes/sec
Test time:                              10 sec
Log file size: 				21.6mb

No serilog:

Dispatching 500 clients
Waiting for results...

Requests:                           589836 hits
Successful requests:                589836 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            58983 hits/sec
Read throughput:                  39002020 bytes/sec
Write throughput:                  5962393 bytes/sec
Test time:                              10 sec

No log:

Dispatching 500 clients
Waiting for results...

Requests:                           592299 hits
Successful requests:                592299 hits
Network failed:                          0 hits
Bad requests failed (!2xx):              0 hits
Successful requests rate:            59229 hits/sec
Read throughput:                  39165528 bytes/sec
Write throughput:                  5987310 bytes/sec
Test time:                              10 sec
