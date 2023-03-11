EXTERNAL returnToHub()
EXTERNAL startRhythmGame()
-> main

=== main ===
[INSERT NAME] Woah, you scared me! Good thing I'm not live
right now, what's up?
    +[Let's play a game!]
        -> continue
    +[Sorry, just checking in on you!]
        -> leave
        

=== continue ===
[INSERT NAME] Sure thing! But don't expect me to hold back.
    ~ startRhythmGame()
-> END

=== leave ===
[INSERT NAME] How sweet! See ya, then!
~ returnToHub()

-> END