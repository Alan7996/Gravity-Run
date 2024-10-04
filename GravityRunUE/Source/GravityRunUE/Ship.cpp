// Fill out your copyright notice in the Description page of Project Settings.


#include "Ship.h"

#include "Kismet/GameplayStatics.h"

#include "Components/InputComponent.h"

// Sets default values
AShip::AShip()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	static ConstructorHelpers::FObjectFinder<USoundCue>
		deathSoundSound(TEXT("SoundCue'/Game/DeathSound.DeathSound'"));
	if (deathSoundSound.Object != NULL)
	{
		deathSoundCue = (USoundCue*)deathSoundSound.Object;
	}
}

// Called when the game starts or when spawned
void AShip::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AShip::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}