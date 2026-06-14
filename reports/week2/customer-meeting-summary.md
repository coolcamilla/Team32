# Meeting Summary

**Date:** 14.06.2026, 15:00  
**Participants:** coolcamilla (Team lead / Project manager), WazzuRunaway (Developer), MarikSH (Game designer), Lilia-Shagidullina (Artist), SunrisEe41 (Technical artist / documentation), Pro100Vorona (Developer), Customer 

---

## Artifacts Demonstrated

- User stories document (10 stories, MoSCoW priorities, two user types: Player and Streamer)
- Figma interactive prototype (digging mechanics, inventory, crafting)
- MVP 0 Unity build (partially shown; Windows crash during session)

---

## Discussion Points

- User story format was questioned by the customer, who noted that UX flow diagrams are more typical in game development; the team acknowledged this.
- MVP 1 scope: digging, tool crafting (shovel, pickaxe), and a basic inventory with resource counters.
- Inventory design: the team described it as closer to Terraria; customer recommended studying Forager as a simpler, more enjoyable reference.
- Leaderboard feature classified as "could have" - potentially useful for speedruns, no implementation plan yet.
- StreamerMod (music replacement for streamers) classified as "won't have" for this course.
- Item dropping mechanic: the team questioned its own rationale; customer advised against a weight/overload system.
- Mouse vs. keyboard input: customer strongly preferred a keyboard-only control scheme (A/D to move, directional digging).
- Digging feel: customer emphasized that satisfying digging feedback is the top priority - the core loop must feel fun above all else.
- Linux build has a folder naming issue; the team has identified a fix.

---

## Decisions

- MVP 1 scope confirmed: digging, crafting (simple recipe system), inventory.
- Drop item dropping / weight system - adds unnecessary complexity.
- Remove mouse input from digging; switch to directional keyboard-based digging.
- Switch block breaking to raycast-based (outer layer only) in the next iteration.
- Study Forager and SteamWorld Dig as primary gameplay references.

---

## Action Points

- WazzuRunaway: implement raycast-based block breaking (outer layer only).
- WazzuRunaway: move crafting UI so it is accessible without a mouse.
- Team: fix Linux build folder naming issue.
- Team: play Forager and SteamWorld Dig for gameplay reference.
- Team: explore art style direction - look for simple, pleasant, fun visual references.

---

## Risks

- Unity build was unstable during the meeting (Windows crash); reliability needs attention before next demo.
- Linux build currently broken due to a folder naming issue in the build output.
- No unique differentiating feature identified yet; customer acknowledged this is acceptable for now.

---

## Feedback

- Customer was positive about the Figma prototype: called it well-executed and praised the team's effort.
- Customer repeatedly recommended Forager as a must-play reference for inventory simplicity and game feel.
- Customer cautioned against over-engineering (weight system, mouse input, item dropping) - keep it simple.
- Customer wants the digging mechanic to feel so good that players want to dig endlessly, regardless of objectives.

---

## Customer Approvals

- Core MVP 1 mechanics approved: digging, crafting, inventory.
- MoSCoW priorities for user stories approved as presented.
- Leaderboard as "could have" approved.
- StreamerMod as "won't have" approved.

---

## Resulting Changes

- Item dropping mechanic to be removed or deprioritized.
- Weight/overload system dropped.
- Mouse input for digging to be removed; keyboard-only controls to be implemented.
- Block breaking to switch from click-anywhere to raycast outer-layer system.
