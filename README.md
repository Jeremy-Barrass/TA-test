# Threat Aware Tech Test

To run the application manually, run the following command from the repo root:

```
.\csharp\filecomparison\filecomparison\bin\Debug\FileComparison.exe .\data\data1.json .\data\data2.json
```

Unit tests should run in Resharper or whatever Test runner your IDE is using.

I originally started this tech test unsure of how to provide two different solutions to compare without switching languages, so started off with two directories, one for C# and one for Node.  I deleted Node after a few hours, when it occurred to me I could just read the file into two different formats, which is what the program now demonstrates.

There are two solutions here:

* 1) Parsing the files into JSON objects and stepping through the results.

* 2) Just taking the file as a string and breaking it out into separate lines to compare.

The first method is clearly superior, producing a highly human readable table of granular differences, and running in approximately 4.5 milliseconds on average.

###Pro###: Easy to read, performance can be logged, Test driven.
###Cons###: Took multiple hours and couple of hundred lines to code.

The second produces a difficult to read list and breaks when run through its performance logger.

###Pros###: Written in half an hour with 82 lines of code.  Built on work for Json Reading method.
###Cons###: Performance logging doesn't work, output is not really comprehensible.

Method two could probably be improved with additional work to sort out the formatting and improve separation of concerns in the Comparer application.  I suspect with that in place it would ultimately take longer on average, as there would be additional processing to make the output human-readable.

I feel I struggled somewhat in the beginning with this task, but once I got into my stride with it, it came together fairly well.  I'm not sure that one hour was a fair time to originally set and should have fed that back sooner, rather than simply running past the deadline.  I would have liked to add more tests for some of the methods, but time constraints made that impractical.  I feel that as Tech Tests go, it is representative of the pressures I might face when working on the Threat Aware Team, however.