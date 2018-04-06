# Bluez-A2DP-Sink
An A2DP sink built with bluez and C#


## Current Status
Currently a mismash of WIP code revolving around getting bluez to work.

## Requirements
- Mono (.Net 4 support at least)
- DBus
- Bluez

## Libraries
- Dbus-Sharp (for communicating with dbus)
- Gstreamer .net wrapper (TBI)

Gstreamer will be used for audio playblack. It currently looks more friendly than dealing with alsa. 

## Building
Currently being built on Ubuntu 17.10 (or whatever is latest), not working on other distros or WSL. 
Trigger build with xbuild (should be distributed with mono)
