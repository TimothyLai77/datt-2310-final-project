-> main

=== main ===
[NAME] Hi!
    +[hey]
        -> hello
    +[...]
        -> nothing
    
===hello===
You say hey... i don't know what to write past here this is just a demo. I also just want to see if this wraps around the panel properly........................................................ .......................... .......................... ..........................  
    +[leave]
        -> leave
    +[stare]
        -> nothing


===nothing===
You just stare at them...
    +[leave]
        -> leave
    +[...]
        ->stare2

==stare2===
You just keep staring...
    +[leave]
        -> leave
    +[...]
        -> stare3
        
        
===stare3===
[NAME] you should leave
    +[leave]
        -> leave

===leave===
you leave. 
-> END