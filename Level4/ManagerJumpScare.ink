-> start

=== start ===
You...
  -> second

=== second ===
I just came to check up on you, the cinema is closing soon. What are you doing?
  +[Geez! Why did you scare me like that?]
    -> third("Hahaha! I scared you? My bad... Were you heading back inside to get something?")
  +[I came outside to take out the trash.]
    -> third("Okay, it looks like you were on your way back inside. Do you need something?")

=== third(response) ===
{response}
  +[Yeah, I forgot my keys...]
    -> fourth("It's okay, I grabbed them for you. Here you go.")

=== fourth(response) ===
{response}
  -> fifth

=== fifth ===
Your shift is over. You can start heading home now..
  -> sixth

=== sixth ===
Tomorrow night you will be closing the theater alone again, and remember.. THE CUSTOMER IS ALWAYS RIGHT!

-> END