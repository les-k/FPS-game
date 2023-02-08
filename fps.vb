import pygame
import random

# Initialize Pygame
pygame.init()

# Set up the window
screen = pygame.display.set_mode((800, 600))

# Load player and target images
player_image = pygame.image.load("player.png")
target_image = pygame.image.load("target.png")

# Set player starting position and target starting position
player_x = 400
player_y = 300
target_x = random.randint(0, 800)
target_y = random.randint(0, 600)

# Load shooting sound effect
shoot_sound = pygame.mixer.Sound("shoot.ogg")

# Set the score to 0
score = 0

# Start the game loop
running = True
while running:
  # Handle events
  for event in pygame.event.get():
    if event.type == pygame.QUIT:
      running = False
    elif event.type == pygame.KEYDOWN:
      if event.key == pygame.K_SPACE:
        # Play the shooting sound effect
        shoot_sound.play()
        
        # Check if the player hit the target
        player_rect = pygame.Rect(player_x, player_y, player_image.get_width(), player_image.get_height())
        target_rect = pygame.Rect(target_x, target_y, target_image.get_width(), target_image.get_height())
        if player_rect.colliderect(target_rect):
          # Increase the score
          score += 1
          
          # Move the target to a new random location
          target_x = random.randint(0, 800)
          target_y = random.randint(0, 600)

  # Clear the screen
  screen.fill((0, 0, 0))
  
  # Draw the target
  screen.blit(target_image, (target_x, target_y))
  
  # Draw the player
  screen.blit(player_image, (player_x, player_y))
  player_rect = pygame.Rect(player_x, player_y, player_image.get_width(), player_image.get_height())
  
  # Display the score
  font = pygame.font.Font(None, 36)
  score_text = font.render("Score: {}".format(score), 1, (255, 255, 255))
  screen.blit(score_text, (650, 550))
  
  # Update the display
  pygame.display.update()

# Quit pygame
pygame.quit()
