# Buildin-Up
-An AR game where player picks a block on top of one marker and build a structure on the other marker-

### Core Design of the Game:

-	Game is based on building a tower using blocks and keeping them on the playground.
-	Player chooses a block from block ground and places it on the playground.
-	With each block that placed on playground player earns a point.
-	If a block falls from the playground to below, game is over.

### Development of the Game:

-	To represent block ground and playground there are two markers and image targets.
-	BlocksGameController class is created to control game states and dynamics.
-	When player selects a block, screen coordinates are taken and turned into a ray cast from the camera view.
-	With ray cast, desired block becomes a child object of AR camera and thus it can be transferred to the other image target.
-	Using the current coordinates of AR camera user can place the block on the desired place on playground.
-	To show current score an in-game canvas is created as a child of AR camera.
-	To understand falling from the playground, an invisible box is created under the playground and a collider trigger added to this box of border.
-	Whenever a block hits the border box gameOver (static variable of BlocksGameController class) is set true.
- To perform AR camera actions, Vuforia SDK is used.

### Screenshots from the Game:


<p>
  <img align="left" src="https://github.com/dogaminekaba/Buildin-Up/blob/master/readme_images/buildinup_img1.png" width="300"/>
  <img align="center" src="https://github.com/dogaminekaba/Buildin-Up/blob/master/readme_images/buildinup_img2.png" width="300"/>
</p>

<p>
  <img align="left" src="https://github.com/dogaminekaba/Buildin-Up/blob/master/readme_images/buildinup_img3.png" width="300"/>
  <img align="center" src="https://github.com/dogaminekaba/Buildin-Up/blob/master/readme_images/buildinup_img4.png" width="300"/>
</p>
