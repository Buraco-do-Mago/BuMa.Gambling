{
  description = "gambling project flake";
  
  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-24.05";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system: let
      pkgs = import nixpkgs {
        inherit system;
      };
    in with pkgs;{
      devShells.default = mkShell {
        buildInputs = [
          dotnet-sdk_8
          dotnet-runtime_8
          dotnet-aspnetcore_8
        ];
      };
    });
}
