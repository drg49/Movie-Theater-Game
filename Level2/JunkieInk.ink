-> start

=== start ===
...
    + [Sir, are you okay?]
        -> oneA("They... They are watching me.")
    + [What are you doing?]
        -> twoA("I am hiding from them..")

=== oneA(response) ===
{response}
    + [Who is watching you?]
        -> oneB("The bug people. They want me dead.")
    + [Try and take it easy for the rest of the night.]
        -> last("Go away.")

=== oneB(response) ===
{response}
    + [Do you need help?]
        -> last("We are all helpless. We are all going to die!")
    + [Sounds like you need to sober up my friend.]
        -> last("You will all be sorry...")

=== twoA(response) ===
{response}
    + [Hiding from who?]
        -> last("The ones underground, they won't stop until I'm dead.")

=== last(response) ===
{response}

-> END
