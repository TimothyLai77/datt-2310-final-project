EXTERNAL returnToHub()
EXTERNAL startPlatformerGame()

-> main

=== main ===

[Matt] Oh hey.
    + [Let's play a game]
        -> start
    + [Just saying hi]
        -> leave
    
=== start ===
    [Matt] Good luck!
    ~ startPlatformerGame()
    -> END
=== leave ===
    Hi!
    ~ returnToHub()
    -> END