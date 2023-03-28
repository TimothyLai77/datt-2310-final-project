EXTERNAL returnToHub()
-> entry

=== entry ===
[Alex] Woah! You're even better than I expected.
    + [Hehe thanks!]
        -> pos
    + [It's not that big a deal...]
        -> neg
    
=== pos ===
[Alex] You should try streaming this game sometime, I'm sure viewers would love it! 
    ~ returnToHub()
    -> END
    

=== neg ===
[Alex] Ouch, just trying to be nice...
    ~ returnToHub()
    -> END


