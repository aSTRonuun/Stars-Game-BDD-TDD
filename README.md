<h1><span style="font-weight: 400;">Star Wars - Game</span></h1>
<p><span style="font-weight: 400;">BDD e TDD</span></p>
<p><strong>Students:</strong><span style="font-weight: 400;">Vitor Manoel Alves da Silva and Rodrigo Moraes de S&aacute; Teles</span><span style="font-weight: 400;"><br /></span><span style="font-weight: 400;">Implemented Scenarios: ✅</span><span style="font-weight: 400;"><br /></span><span style="font-weight: 400;">Not Implemented: ❌</span></p>
<p>&nbsp;</p>
<table>
<tbody>
<tr>
<td>
<p><span style="font-weight: 400;">Card(story name)</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Conversation</span></p>
<p><span style="font-weight: 400;">(data there you will need)</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Confirmation (scenarios)</span></p>
</td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">Positioning of ships:</span></p>
<br />
<p><span style="font-weight: 400;">The system should place ships on the board randomly</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Cell info:</span></p>
<br />
<p><span style="font-weight: 400;">Position (vertical/horizontal) that will position the ships and position (letter and number)</span></p>
<br />
<p><span style="font-weight: 400;">(1 - StartHunt TIE/LN (1x1)</span></p>
<br />
<p><span style="font-weight: 400;">2- Millenium Falcon &nbsp; (2x2)</span></p>
<br />
<p><span style="font-weight: 400;">3- Destroyer</span> <span style="font-weight: 400;">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; (2x3)</span></p>
<br />
<p><span style="font-weight: 400;">4- Imperial Class (4x1)</span></p>
<p><span style="font-weight: 400;">)</span></p>
<br />
<p><span style="font-weight: 400;">Board information:</span><span style="font-weight: 400;"><br /><br /></span></p>
<p><span style="font-weight: 400;">The board can be started by difficulty levels</span></p>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Easy: 10x10</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">50 chance to hit</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Medium: 15x15</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">45 chance to hit</span></li>
</ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Hard: 20x20</span></li>
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">40 miss chances</span></li>
</ul>
</ul>
<br /><br /></td>
<td>
<p><em><span style="font-weight: 400;">1- Positioning of ships in an unused cell: ✅</span></em></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game has started and the game difficulty has been chosen</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The system tries to place the ship in an empty cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The system should be able to position your ship successfully</span></p>
<br />
<p><span style="font-weight: 400;">2- Ship positioning in off-grid cell: ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game has started and the game difficulty has been chosen</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The system tries to place a ship off the grid</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">Unable to add ship in a cell</span></p>
<br />
<p><span style="font-weight: 400;">3- Ship positioning overlapping other ships: ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game has started and the game difficulty has been chosen</span> <span style="font-weight: 400;">and there is a ship at the chosen coordinate</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The system tries to position a ship</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">Unable to add ship in a cell</span></p>
</td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">Choice of trigger cell:</span></p>
<br /><br />
<p><span style="font-weight: 400;">Me as a player I can shoot the opponent player</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Point count:</span></p>
<br />
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">For each ship knocked down, the player Rodrigo earns 1 point</span></li>
</ul>
<br />
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Unused cell is a dot (~)</span></li>
</ul>
<br />
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Cell already used and that did not have a vessel has an at sign (@)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">Cell already used and that had a vessel has a cross (X)</span></li>
</ul>
</td>
<td>
<p><span style="font-weight: 400;">1 - Choice of untriggered cell: ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game has started</span></p>
<p><span style="font-weight: 400;">Ships were placed on the grid by the player</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The player fires on the non-empty cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The game displays a message saying that the cell was fired successfully</span></p>
<br />
<p><span style="font-weight: 400;">2- Choice of cell already fired ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game started and</span></p>
<p><span style="font-weight: 400;">The ships were positioned on the grid</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The player fires at the previously fired cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The game displays an error message stating that the cell has already been fired</span></p>
<br />
<p><em><span style="font-weight: 400;">3- Invalid cell choice (outside the grid) for triggering</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">The game has started</span></p>
<p><span style="font-weight: 400;">The ships were positioned</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">The player shoots a cell outside the grid</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The game displays an error message stating that the chosen cell is invalid</span></p>
<p><span style="font-weight: 400;">The player must choose a cell within the grid to fire</span></p>
<br /><br /></td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">name choice</span></p>
<br />
<p><span style="font-weight: 400;">I as a player want to choose my name to play the game</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Required fields:</span></p>
<br />
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Player's name</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">Valid Characters (Only letters and numbers)</span></li>
<li style="font-weight: 400;"><span style="font-weight: 400;">(Name string length: 20)</span></li>
</ul>
</td>
<td>
<p><em><span style="font-weight: 400;">1- Choose a valid name</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I want to choose my name</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">I type my name with valid characters and within the character limit</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The system should accept my name</span></p>
<br />
<p><em><span style="font-weight: 400;">2- Invalid character choice</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I want to choose my name</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">I type my name with invalid characters</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The game displays an error message</span></p>
<p><span style="font-weight: 400;">The game asks me to enter a valid name again</span></p>
<br />
<p><em><span style="font-weight: 400;">3- Choice of name beyond the limit:</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I want to choose my name</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">I type my name that exceeds the character limit</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The game displays an error message</span></p>
<p><span style="font-weight: 400;">The game asks me to type a name again and that it is within the character limit</span></p>
<br /><br /></td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">win score</span></p>
<br />
<p><span style="font-weight: 400;">I how to play can I earn points when I hit a ship or part of it</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Data</span><span style="font-weight: 400;"><br /></span><span style="font-weight: 400;"><br /></span><span style="font-weight: 400;">Each hit gives 10 score points to the player</span></p>
</td>
<td>
<p><em><span style="font-weight: 400;">1- Attack on a cell that contains ship</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I attack a ship</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">There is a ship in the cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player must receive 10 score points</span></p>
<br />
<p><em><span style="font-weight: 400;">2 - Attack on a cell that does not contain a ship</span></em></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I attack a ship</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">There is no ship in the cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player must not receive the score</span></p>
</td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">Star Cannon ammo</span></p>
<br />
<p><span style="font-weight: 400;">As I play, I can spend ammo (chances) when I miss and hit a ship or part of it</span></p>
</td>
<td>
<p><span style="font-weight: 400;">Data</span></p>
<br />
<ul>
<li style="font-weight: 400;"><span style="font-weight: 400;">Each attack uses up ammo.</span></li>
</ul>
</td>
<td>
<p><em><span style="font-weight: 400;">1- Attack on a cell that contains ship</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I attack a ship</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">There is a ship in the cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player must spend 1 ammo</span></p>
<br />
<p><em><span style="font-weight: 400;">2 - Attack on a cell that does not contain a ship</span></em></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I attack a ship</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">There is no ship in the cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player must spend 1 ammo</span></p>
<br />
<p><em><span style="font-weight: 400;">2 - Attack that has been hit before</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">I'm a player and I attack a ship</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">There is no ship in the cell</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player must spend 1 ammo</span></p>
</td>
</tr>
<tr>
<td>
<p><span style="font-weight: 400;">End of the game</span></p>
<br />
<p><span style="font-weight: 400;">I as a player can win or lose the game</span></p>
</td>
<td>
<p><span style="font-weight: 400;">-</span></p>
</td>
<td>
<p><em><span style="font-weight: 400;">1- Win game when all ships were hit</span></em><span style="font-weight: 400;"> ✅</span></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">That the player still has ammo available</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">It attacks a ship and there are no more ships to be hit.</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">The player won the match</span></p>
<br />
<p><em><span style="font-weight: 400;">2 - Lose game when ammo runs out</span></em></p>
<br />
<p><strong>Given:</strong></p>
<p><span style="font-weight: 400;">That the player has no more ammo available</span></p>
<br />
<p><strong>When:</strong></p>
<p><span style="font-weight: 400;">He attacks a ship</span></p>
<br />
<p><strong>Then:</strong></p>
<p><span style="font-weight: 400;">the game is over</span></p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>