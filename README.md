UsingSongGetter is a easy to use Program, to get your Current Playing Song and 
Display it for example in your Livestream.

With the UsingSongGetter you Can get your Currently Playing song from:

- Spotify
- InternetExplorer(YouTube, SoundCloud)

and write it to a text file.

UsingSongGetter's main Purpose is to help Streamers to Display their Currently
Playing Music in a Stream Overlay.

How To use:

OBS: 

- Add a Text Component to your Scene.
- Check the box Labeled "Read from File".
- Click on "Browse" next to Textbox.
- Select "C:/Users/YOURNAME/AppData/Roaming/UsingSongGetter/currentSong.txt".
- Click "Open".

Xsplit:

- Select "Add source".
- Check the box Labeled "Use Custom Script".
- Click on "Edit Script".
- From the "Template" Dropdown Select: "Load Text from Local File".
- Click the 3 Points next to the "File Path" Textbox.
- Select "C:/Users/YOURNAME/AppData/Roaming/UsingSongGetter/currentSong.txt".
- Click "Open".

UsingSongGetter uses the following libarys:

- SpotifyAPI-NET
- Newtonsoft.Json