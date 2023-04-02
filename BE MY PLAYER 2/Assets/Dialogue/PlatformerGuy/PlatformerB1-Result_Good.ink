EXTERNAL returnToHub()

-> main

=== main ===
    [Matt] Wow. Really nice job.
    +[Thank you! I’ve been practising.]
        -> thanks
    +[Omg really? I mean… I’m better than you anyways.]
        -> better
        
=== thanks ===
    [Matt] It’s paying off. A little more and you’ll reach me.
        +[You think so?] 
            -> seeya1
        +[No waaay.]
            -> seeya2

=== seeya1 ===
    [Matt] Yeah for sure. I’m going live soon. I’ll see you around.
    +[Seeya]
        -> finish
    
=== seeya2 ====
    [Matt] Yes way. I’m going live soon. I’ll see you around.
    -> finish
    
    
    
=== better ===
    [Matt] In your dreams.
        +[Believe me. You don’t stand a chance.]
            -> betterEnd1
        +[Oh yeah? Lemme come back tonight and prove it.]
            -> betterEnd2


=== betterEnd1===
    [Matt] Alright alright, you should watch my stream if you have the chance and I’ll show you how it’s done.
        +[Say no more! See ya!]
        -> finish
=== betterEnd2===
    [Matt] That’s a lot of confidence. I like that. I’m streaming tonight so maybe tomorrow.
        +[Okay bet! Byeee]
        -> finish

=== finish ===
    ~returnToHub()
    -> END