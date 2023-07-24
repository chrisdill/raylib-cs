```sh
# clear nuget local cache if you install raylib-cs from nuget before
dotnet nuget locals all --clear

# install android sdk requirements
# or just install it from visual studio
sdkmanager "build-tools;34.0.0" "ndk;25.2.9519653" "platforms;android-34"

# install android workload
dotnet workload install android

# download artifact.zip from https://github.com/anggape/Raylib-cs/actions/runs/5630394074 and extract it
dotnet restore --source <path to extracted artifact.zip>

# connect your android device or create new emulator
adb devices # make sure your device there

# run project
dotnet run
```
