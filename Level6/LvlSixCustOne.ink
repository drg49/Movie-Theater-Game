-> start

=== start ===
Excuse me.
  +[Yes, how may I help you?]
    -> one("The sound in the movie theater is a bit loud. Could you turn it down?")
  +[What do you want?]
    -> two("That is no way to answer customers, where is your manager?")

=== one(response) ===
{response}
  +[I cannot do that, I'm sorry.]
    -> oneA("Are you serious? WHY NOT!")
  +[It is not that loud. Can you move farther away from the speakers?]
    -> oneB("No I am not going to do that.")

=== oneA(response) ===
{response}
  +[It is against our policy.]
    -> oneAB("Okay fine, I want a large popcorn and a small diet cola.")
  +[Because then others will complain it is too quiet.]
    -> oneAB("Whatever, give me a large popcorn and a small diet cola.")

=== oneAB(response) ===
{response}
  -> END

=== oneB(response) ===
{response}
  +[Okay, well can I get you something else?]
    -> oneC("Yes, I want a large popcorn and a small diet cola.")

=== oneC(response) ===
{response}
  -> END

=== two(response) ===
{response}
  +[He is not here at the moment.]
    -> twoA("That is not acceptable. Get him here now, you are in trouble..")

=== twoA(response) ===
{response}
  -> END

