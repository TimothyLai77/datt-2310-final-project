EXTERNAL returnToHub()
EXTERNAL startRhythmGame()
-> main

=== main ===
[Alex] Woah, you scared me! Good thing I'm not live right now, what's up?
    +[Let's play a game!]
        -> continue
    +[Sorry, just checking in on you!]
        -> leave
        

=== continue ===
[Alex] Sure thing! But don't expect me to hold back.
    ~ startRhythmGame()
-> END

=== leave ===
[Alex] How sweet! See ya, then!
~ returnToHub()

-> END