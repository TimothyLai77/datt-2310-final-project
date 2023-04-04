EXTERNAL returnToHub()

-> entry

=== entry ===
[Alex] Wow, you're reaction time is insane! Nowhere close to mine, though!
    + [I bet I'm even better.]
        -> one
    + [I'm not THAT great...]
        -> two
        
=== one ===
[Alex] What a tease! I'm about to go live right now... maybe come back tomorrow and I'll show you just how good I am!
    ~returnToHub()
    -> END
    
=== two ===
[Alex] Jeez, just trying to give you a compliment...
    ~ returnToHub()
    -> END