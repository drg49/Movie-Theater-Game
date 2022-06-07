-> start

=== start ===
BOO!
  + [Where am I?]
    -> first("You are on a set. You are the lead role in my upcoming hit movie! Are you ready?")
  + [What am I doing here?]
    -> first("You're acting. I chose you to be the lead actor in my film. Are you ready?")

=== first(response) ===
{response}
  +[I don't want to be your actor. Get me out of here!]
    -> second

=== second ===
You have no choice! You will act in my movie and you will enjoy it!
  -> third

=== third ===
Your goal in this movie is to find 6 bags of popcorn.
  -> fourth
== fourth ===
However while doing so, you will meet a friend of mine...
  -> fifth

=== fifth ===
If you find all 6 bags of popcorn, you will be rewarded. If not, you will beg for mercy..
  -> sixth

=== sixth ===
Lets hope you can get out of this alive...
  -> END

-> END