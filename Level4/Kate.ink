-> start

=== start ===
Have you been reading the papers lately?
  +[No, what's going on?]
    -> two

=== two ===
There have been random blackouts throughout the neighborhood, the electric company still doesn't know why they are happening...
  +[That's strange.]
    -> three("It really is. I'm surprised you haven't experienced one yet. Having no power is the worst.")
  +[What do you expect? The electric company sucks!]
    -> three("Yeah that's true I guess. You never know what to expect from them. Anyways, walk home safe.")

=== three(response) ===
{response}

-> END