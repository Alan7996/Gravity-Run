// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Laser.h"

#include "Components/SphereComponent.h"
#include "SoundDefinitions.h"
#include "Sound/SoundCue.h"

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "Ship.generated.h"

UCLASS()
class GRAVITYRUNUE_API AShip : public APawn
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	AShip();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	USphereComponent* ShipSphereComponent;

	USoundCue* deathSoundCue;
};
