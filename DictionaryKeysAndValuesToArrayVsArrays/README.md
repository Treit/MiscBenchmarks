# Dictionary vs arrays to produce two separate sets of strings
Using a Dictionary as a bag to hold sets of keys and values and then passing those to methods that require arrays, vs. just building two arrays. This was seen in some production code in a hot path and thus allocating a lot more memory than necessary.
