[Unrelated to the review]

**[01:38] coolcamilla:** So, here’s what we did this week. To be more specific, our goal was to build the game. That involved polishing the interface, fixing a few bugs - actually, just one - and improving immersion and game balance. By the end of this week, we’ll finish MVP v3. We’ve already added cutscenes and a mini-tutorial, and we’ve updated the burer interface based on the mockup we discussed last week. We’ve also divided stamina into sections, redesigned all the buttons, implemented them, and added new recipes. Well, to be more precise, we’ve slightly updated the existing recipes. There you go. And we’ve changed the map - now there are transparent walls along the edges instead of white ones, and all the important objects, like the drill and so on, are centered. And most importantly, most importantly, there’s no more digging with the mouse. Actually, you can dig using both the keyboard and the mouse.  
**[02:50] customer:** Ooookay, guys, all right.  
**[02:55] coolcamilla:** I’ve already listed what we’ve done. Oh, and we also added a warning that your stamina is running low. Now, regarding what we haven’t finished yet for this meeting, but we’ll wrap it up over Friday and Saturday: saving. Next, opening recipes in the crafting menu: not by clicking, but just by hovering the mouse over them. All the recipes have already been designed, but not all of them have been implemented in the game yet, so that will be added too. Also, the construction menu panel will be replaced with a new, redrawn one. Well, not exactly new - it’s the one we already have. And we’ll be deploying it to itch.io soon. As for what we definitely won’t be doing: basically, the key remapping for this little menu - we discussed that last week - and improvements for the mole are definitely out too. And then there’s this “corner-grab jump” that’s been getting pushed from sprint to sprint; that won’t be happening either. I have no idea why we even made it in the first place. It just gets pushed back from sprint to sprint and never gets done. That’s basically it. I also posted the backlog there. If you’re interested, you can check it out too.  
**[04:21] customer:** Okay, thanks.  
**[04:23] coolcamilla:** There you go. So now, basically, you should play through the tutorial a bit first, and then you can just play freely. And to start with, you can check out the cutscenes.  
**[04:33] customer:** So, can you see my screen share at all?   
**[04:35] coolcamilla:** Yes, yes, I can see it.  
**[04:37] customer:** Great.  
**[04:35] coolcamilla:** And at the beginning, you can check out the cutscenes we’ve added. So…  
**[04:45] customer:** Can I check out the settings?  
**[04:47] coolcamilla:** No.  
[inaudible]  
**[04:52] customer:** They unlock gradually, right? We need to make some progress...  
**[04:47] coolcamilla:** If you finish the game, maybe the settings will unlock.  
**[05:03] customer:** Right after the secret ending. The secret settings.  

### [UAT session starts]

**[05:07] coolcamilla:** Now click the “Start” button.  
**[05:15] customer:** Oh, they even added a normal font.  
**[05:18] coolcamilla:** This is our introductory cutscene. It tells the mole’s backstory.  
**[05:37] customer:** Okay, well, it’s enough to bring tears to your eyes, yeah.  
**[05:45] coolcamilla:** Now the tutorial is starting with the arrow.  
**[05:50] customer:** So, I need to click on the arrow with the mouse, right?  
**[05:53] coolcamilla:** Yes.  
**[05:57] customer:** It would be great to indicate that they’re clickable - otherwise they’re really annoying. “Press F or J”… Guys, how did you even come up with these buttons? You should update the fonts on the interactive objects. Overall, what you’ve done is great. It’s just too much already, guys.  
**[07:01] SunrisEe41:** We just have a lot of mechanics.  
**[07:04] customer:** No, I get it. It’s just that… Players will forget everything. Everything that happened. It’s kind of… You’ve gone overboard. I mean, you could have simplified things a bit for players who come in and take a look. Overall, it’s good that the different actions are laid out step-by-step throughout. That’s cool. [inaudible]  
**[07:45] coolcamilla:** Now we can try making a tool. We need to gather at least 12 sticks for now, and most importantly, don’t collect 7 stones.
**[08:05] customer:** Okay. Why does the mole freeze?  
**[08:15] coolcamilla:** They’ll fix that. Basically, they’ve already figured out how to fix it; they just haven’t fixed it yet.  
**[08:24] customer:** Okay. [inaudible] It’s better to make the background 2D, otherwise your [inaudible] breaks. So, the mole gets stuck on the ground pretty often. So, the inventory is still there, right?  
**[09:08] coolcamilla:** Yes, on E.  
**[09:15] customer:** It would be good if you also indicated that such-and-such has been obtained. In a section of the screen. Usually this is done either on the left or on the right with a banner. It’s quick to do; the element isn’t complicated. Just an icon and some text. Look for some references. So, I think I already have the right number of sticks. What’s our next step?  
**[09:49] coolcamilla:** Go to the workbench.  
**[09:53] customer:** Yeah, and we need to do something about this, too.  
**[09:56] coolcamilla:** The fact that it’s crawling through the air.  
**[10:01] customer:** It’s crawling, yeah. It’s one thing for it to crawl on the ground, but it’s another for it to crawl through the air. So, when it’s on an air tile, it should immediately be taken out of that mode. And another question: why the F key?  
**[10:33] coolcamilla:** The programmers decided that. Oh, or in the design...  
**[10:39] customer:** The programmers... How long has it been since you played games?  
[inaudible]  
**[10:55] customer:** Like, what were you basing it on when you assigned the letter F for a malfunction?  
[inaudible]  
**[11:17] customer:** Okay, so there’s a shovel. But there’s still no indication.  
**[11:26] coolcamilla:** What kind of indicator?  
**[11:29] customer:** An indication of what we’ve done. I mean, the key thing missing here is that you don’t know what’s been done, what hasn’t, what’s there, and what isn’t. What’s next?  
**[11:48] coolcamilla:** Well, we’ll see. We’ll try to add it, of course, but I’m not sure how long it’ll take.  
**[11:56] customer:** Well, the indicator is basically just a status indicator. If a player has a certain resource, we show a specific icon. It’ll take a couple of minutes, guys.  
**[12:11] coolcamilla:** Okay. Overall, the goal there was to check what’s being crafted. Now, regarding the drill - here’s the new interface. Let’s see what you think.  
**[12:26] customer:** All good.  
**[12:28] coolcamilla:** Better than the previous one.  
**[12:30] customer:** Yeah, better than the previous one. It’s kind of a font thing. Anyway, here, for example, it looks fine. I think the sizes are different. But here, guys, you have… Not the sizes, but the Caps Lock… Oh wait, it’s there. Yeah, the sizes do seem different. Anyway, it looks really bad on the buttons. [inaudible] all the buttons - plus you’re stretching them vertically, which makes them look off for some reason. Plus, the padding is very small. Everything needs more padding; you can make the text smaller yourself. It’s just that right now, because everything’s right up against the edges, it’s ruining the overall look. That applies to the buttons, too. So just make the text smaller and make it fit better within the button. You can take another look at how buttons are designed on regular websites and what kind of spacing they usually use. Oh, here we go, here we go, here we go. (customer started the drill)  
**[13:42] coolcamilla:** Okay, now you can make some improvements as well.  
**[13:50] customer:** Bam-bam-bam. Everything’s added. Bam-bam-bam. (customer refuels the drill) What do you mean, make improvements?  
**[14:05] coolcamilla:** Yeah, well, the drill is on the to-do list. Anything goes.  
**[14:08] customer:** The drill? Let’s do it, let’s do it. Yeah, and, of course, we’re missing the interface and other elements we have. I mean, the whole interface is built around the fact that we have to spend something, but the player can’t see what to spend or how much they have… the amount. It would also be good here, of course, to show that an upgrade is available. Just, for example, make the background red, or the button red. Well, guys, it’s pretty basic. But this can be set up very quickly. So, hypothetically, this is us… Yeah, we did that. [Inaudible] works.
**[15:06] coolcamilla:** So overall, the last thing we need to verify step by step is stamina again.  
**[15:19] customer:** Our stamina is still regenerating anyway. I mean, if…  
**[15:24] coolcamilla:** Yes, it’s still regenerating in normal mode. We decided to… We haven’t done this yet, as far as I understand. We decided to implement a very slow recovery in normal mode. And, accordingly, when he drinks beer, his recovery speed increases, his stamina reserve goes up, and his stamina automatically replenishes. But in normal mode, it just takes a very long time to recover. And now you need to… Well, you’ve probably already noticed that when, say, half a bar is left, a red warning pops up.  
**[16:17] customer:** Yes.  
**[16:24] coolcamilla:** And just like that, the character dies - he just dies.  

### [UAT session ends]
### [Customer trial session starts]

**[16:29] customer:** What’s going on with the animation? Did you fix anything over there? You have the digging animation running right now, and it’s still looping incorrectly. For example, when I pause the movement, everything’s fine… we take a step. With the digging animation, you’re doing two attacks at once, even though I only pressed the button once. And it’s going from bottom to top, not top to bottom. That really kills the immersion. Because it doesn’t feel like a natural reaction to the action. It’s very jarring. But if we go in a circle now, we’ll get back to where we wanted to go, right?  
**[17:41] coolcamilla:** Right now, well, right now... Oh, no, I mean, like, you can’t really go through here anymore.  
**[17:51] customer:** Yeah. Will you have time to make the circular world?  
**[17:57] coolcamilla:** What exactly do you want me to do?  
**[18:00] customer:** Like we discussed, the circular world. You know, when you walk around it.  
**[18:04] coolcamilla:** I don’t think so… it’s hard…  
**[18:15] SunrisEe41:** How would that even work, roughly speaking?  
**[18:18] WazzuRunaway:** Yeah, just conceptually.  
**[18:23] customer:** Could you repeat that, please?  
**[18:26] SunrisEe41:** How would that work, roughly? I don’t quite understand.  
**[18:35] customer:** Well, you have a map - let’s say we take this section, up to this point, as the camera view. At a certain point - as is usually done - the player teleports, and movement across the map begins. You can look for a solution here - different games use different approaches. You could try making a 3D map. It might turn out to be expensive, or it might turn out to be cheap. I’d probably just watch a video or ask someone on GPT, because the context can very quickly suggest how to implement it. Because maybe it’s just a matter of a pseudo-scrollbar - meaning you’re actually running around on a 3D plane. By the way, it would be funny if the mole ran around the Pit on a 3D plane. Like in *Angels*. But in *Angels*, it was totally wild. It was totally crazy over there. Anyway, there’s a lot of polishing to be done. Plus, the drill feature isn’t readable to the player right now. The most readable feature is the beer, guys. It would also be good to highlight the buttons you can interact with. If, for example, I don’t have enough money, then the letter “F” should be highlighted in red too. But you’d still need to work on the font a bit. Actually, there are a lot of fixes, but they’re mostly minor ones. Do you guys have a clear goal now?  
**[20:45] coolcamilla:** Like, to finish the game?  
**[20:48] SunrisEe41:** No, this is kind of the finale.  
**[20:51] coolcamilla:** Oh, well, the ending has appeared. When the drill, you know, digs all the way to... Like, it digs through the whole rock there…  
**[21:01] customer:** And you should make it so you can exit that screen quickly; otherwise, it’s really slow.   
**[21:04] coolcamilla:** …That final scene.  
**[21:09] customer:** Although, overall, it’s fine… Anyway, we should tinker with it a bit. Okay, let’s go down.  
**[21:19] coolcamilla:** And over there right now…  
**[21:20] customer:** I don’t know what’s waiting for us there.  
**[20:21] coolcamilla:** …Whether the mole is digging or not, he’s just much faster now overall - he gets to the end, and you can have him keep digging in the background.  
**[21:31] customer:** Add blocks with coins. Even the ones we discussed. Right now there are blocks with coins, but the coins aren’t indicated at all. Well, I mean, there’s absolutely no value in the mole not being able to see far. Okay. Do these blocks break?  
**[21:57] coolcamilla:** Stone or...  
**[22:00] customer:** Yes. If we upgrade it further.  
**[22:03] coolcamilla:** Well, if you upgrade it, then yes, they’ll break. Well, to level up right now, you need your drill to hit a stone layer. And you have to drill all the way through it. You kind of need a large stone for that, but you don’t have a large stone. Basically.  
**[22:23] customer:** Yeah. Well, the player won’t understand that. I’ll warn you right away that it’s not very clear right now… that the drill is breaking through, because there’s no visual feedback. If you had at least this thing that, let’s say, drills deeper and deeper and deeper and deeper inside here, and somehow, when it reaches the right level, for example, it starts to vibrate… well, you know, this needs to be visualized directly. Again, guys, there are still a lot of fixes needed for it to work properly. So, the way it is now, if I feed the drill, it’ll turn out…  
**[23:29] SunrisEe41:** It’ll quickly dig down to the rock, and in that rock… Well, that’ll be the end of it when it reaches the bottom of the rock.  
**[23:50] customer:** By the way, can you make more improvements? Right now it’s just one at a time.  
**[23:54] coolcamilla:** They’re there - it’s just that, well, they’ve been planned out, but they’re just sitting there...  
**[24:10] customer:** So, how do I know where the drill is right now?  
**[24:15] coolcamilla:** There’s dirt there. Like, the background is dirt. He’s moving pretty fast there. I think the rock will start about three meters from there.  
**[24:32] customer:** Uh-huh, okay. Then we’ll wait. And again, it’s critically important that you show in a section of the screen that you’ve collected a certain number of sticks - in parentheses - so I can see my total number of sticks. Right now, it’s completely unclear what you’re collecting or how many you’re collecting. The player has no way to measure that. So, it turns out there are 3 meters, and right now he has to break through the rock, right?  
**[25:15] SunrisEe41:** 3.5 meters.  
**[25:22] customer:** And will we be able to see that? The drill in action.  
**[25:33] SunrisEe41:** The drill is in our heads…  
**[25:41] customer:** Great.  
**[25:46] SunrisEe41:** Well, it’ll show that he has a stone background and that he’s digging in the stone.  
**[26:00] customer:** Okay. And where? Like, the stone’s on top right now, right?  
**[26:09] coolcamilla:** Yes.  
**[26:31] customer:** That [Inaudible] is also really inconvenient. It would be more convenient if you just displayed it right away - without having to do anything extra. [Inaudible]... Okay, we’ll wait.  

### [Customer trial session ends]
### [Transition Confirmation starts]

**[26:58] coolcamilla:** Well, overall, we’ll wait for now; we still need to discuss it further:** in short… ah, well, SunrisEe41 is probably here  
**[27:11] SunrisEe41:** About the transition?  
**[27:12] coolcamilla:** Yeah, yeah  
**[27:15] SunrisEe41:** Well, I can handle it. Regarding the transition - what we discussed last week - if we take the current documentation we have on GitHub and deploy it to itch.io after these fixes we manage to make and the entire repository handover, will the handover stage still be complete? The handover itself, to be precise.  
**[28:00] customer:** Overall, as we discussed, the main thing is that we have a build on itch.io, Git, and everything else in place. So, back to the pitch… I’m not forcing you to pitch. It’s just that… Well, we’ve already discussed that you all have your own plans moving forward.  
**[28:31] coolcamilla:** And here’s another question.  
**[28:36] customer:** Right now, we can upgrade this pickaxe, right?  
**[28:40] coolcamilla:** What can we do?  
**[28:42] customer:** Right now we can upgrade this pickaxe and use it to break new blocks, right?  
**[28:47] coolcamilla:** Yeah, well, you’ll be able to break them with the stone pickaxe too. Basically, anything can be broken with any pickaxe now. Here’s another question. Well, you’d probably say right now, “When are we going to fix all this?” but we clearly won’t have time to fix everything. Should this still be accepted as is? Without taking it into account, or something?  
**[29:08] customer:** No, if it isn’t fixed, the project won’t be accepted. Everyone gets a D. Everyone’s up for the chopping block. Just kidding. Guys, we need to polish up the file system. Right now it’s very rough, so at least polish up the animations - or at least the system itself, which can be done quickly. In other words, prioritize what I wrote based on importance and cast roles, and obviously don’t do the things that take a long time. But the quick little things - specifically related to the film - can really be done in a flash. It’ll speed things up just like that. And by doing this, you’ll be doing your players - who will still come to your game and still play it - a huge favor.  
**[30:06] coolcamilla:** And then...  
**[30:09] customer:** Please do the things that can be done quickly. Just check the time.  
**[30:14] coolcamilla:** And then there’s another question. Like… Well, basically, is the project ready for you to use on your own, and will you play it? Or something like that… Well, once it’s uploaded to itch.io.  
**[30:34] customer:** Well, I won’t be the only one playing it. Yeah. I mean… That’s a shame. Or did I hear that wrong?  
**[30:44] coolcamilla:** No, no, no.  
**[30:46] customer:** You’re adding to it, and you’ll have a really good little project for your portfolio. Just make it, well, a little more polished.  
**[30:54] coolcamilla:** Then I have another question.  
**[30:56] customer:** It’s already pretty good as is. Well, polish, polish, polish… yeah.  
**[31:09] coolcamilla:** So, are you planning to refine the game yourself or change your code in any way?  
**[31:18] customer:** Not without you guys.  
**[31:20] coolcamilla:** Okay.  
**[31:21] customer:** Well, sort of, if everyone else drops out of development. I mean, if the vibe’s right, we could re-release it on a new platform.  
**[31:36] coolcamilla:** And then one last thing - the limitations we’re aware of, and which we’ve identified since the course - is that there’s not much content in the game yet, the gameplay isn’t very balanced, and the physics sometimes glitch a little. So in terms of...  
**[31:55] customer:** That’s nonsense - I mean, the balance is generally fine right now, like… It’s not so much about the balance itself as it is about making exploration interesting. Because right now, exploration isn’t interesting - you just have the same blocks everywhere. As soon as the blocks start having different values, everything will change drastically.  
**[32:17] coolcamilla:** Well, that’s about it, then. Thanks, everyone.  
**[32:32] customer:** Well, the game is really addictive. I mean, you’re just walking around, like, bam-bam-bam-bam-bam-bam-bam. With [Inaudible], just hang out a little longer and polish it up some more. If you, WazzuRunaway, feel like it, you know, at least polish up the graphics a bit.  
**[32:52] WazzuRunaway:** Yeah, sure. Polish it up now, and then… we’ll figure it out later.  
**[33:00] customer:** Well, we could, again, stop developing this project for now and move on to something else - just, guys, finish this up. This is so we can actually show it off. By the way, you can move the pickaxe to the bottom left of the screen, since there’s only one of them. And while you’re at it, show how many of each item we have there. Just take a look at similar apps. Right now, we really just need a few small features to make this look great. That’s it. That’s all I have, really. It was great to hear from you. It was great to see your mole and watch your tutorial.  
**[33:56] SunrisEe41:** Thank you.  

[Unrelated to the interview]

[End of the Interview]
