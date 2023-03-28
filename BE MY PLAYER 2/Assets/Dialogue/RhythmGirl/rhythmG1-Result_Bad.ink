EXTERNAL returnToHub()

-> entry
=== entry ===
[Alex] Really? You're sense of rhythm needs some improvement. Try practicing next time you play with me.
    + [Don't need be so harsh!]
        -> one
    + [I know, right?]
        -> two
        
        
=== one ===
[Alex] Well how else would you get any better!? You're numbers will go down if you don't get better.
    ~returnToHub()
    -> END

== two ===
[Alex] Huh? Well, don't just sit there and sulk over it...
    ~returnToHub()
    -> END
