-> start

=== start ===
Well hello there, hope you're ready for your first night of work.
    -> second

=== second ===
There are a couple of things to consider, it's really simple.
    -> third

=== third ===
First off, tonight is classic movie night. We will be showing only the movies on display.
    -> fourth

=== fourth ===
Remember, the customer is always right, do everything they say. Also, popcorn is 10% off on Fridays, which is tonight.
    -> main

=== main ===
Last thing, the manager wants you to close alone tonight. You think you can do that?
    + [Yes, of course.]
        -> last("Cool, your shift ends at midnight. Go ahead and clock in on the computer.")
    + [Why just me?]
        -> oneB("The theater is small enough for you to take care off. Besides, we rarely get a large crowd here.")
    + [No way, I just started working here!]
        -> last("Well too bad, you don't have a choice.. Now go clock in on the computer.")


=== oneB(response) ===
{response}
    + [Okay, where do I clock in again?]
        -> last("Use the computer behind me, it's the only one you can clock in to.")


=== last(response) ===
{response}

-> END