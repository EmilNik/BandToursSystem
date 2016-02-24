# SimilarBeads

[![Build status](https://ci.appveyor.com/api/projects/status/a7ak43j349y8wv6a?svg=true)](https://ci.appveyor.com/project/EmilNik/similarbeads)

# Documentation



# App

SimilarBeads is a web app for music lovers. They cna share and listen to their songs and the ongs of other artists. Also artists can create concerts and all users can see the concerts in their city. 

# Database

## User 

string Id

string Name(maxLength(30))

bool IsArtist

bool IsAdmin

string AvatarUrl

virtual ICollection<User> Favourites

string Description

int? Subscribers

ICollection<Genre> Genres

ICollection<Song> Songs

ICollection<Concert> Concerts

## Song

int Id

string Name(MaxLength(50))

string ArtistId

User Artist

int NumberOfPlays

string SongUrl

## Genre

int Id

string Name(maxLength(30))

## Concert

int Id

string City

string ArtistId

User Artist

DateTime Date

# Routes

## HomePage

The home page shows the app statistics. Number of users, songs, concert... 
Also the home page shows the top 10 artists ordered by the number of their subscribers and top 10 songs ordered by the number of times each song has been played.

# Public part

Each site visitor that is not logged in can see the home paga and the lists with top artists and top songs.

## Top Songs

A pageble list of all songs in the database. They can be sorted.

## Top Artists

A pageable list of all artists in the database. They can be sorted in every column.

# User part

## Concerts

Each registered user can see the list of concerts. The list is sortable and pageable.

## User Details Page

Each registered user can see its details page and the details page of each user. There is a list of the user's songs
You can play the songs and delete the songs in your profile

# Artits area

## Add Song

Each artist can add a song
Each song has Name

## Add Concert

Each artist can add a concert
The concert has a City and a Date

# Admin Area

## Users

A kendo grid that shows all users(id, email, username, numberOfSubscribers..)
Users can be deleted and updated by the administrator

## Songs

A kendo grid that shows all songs(id, name, artistName...)
Songs can be deleted and updated by the administrator 