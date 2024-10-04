// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Laser.h"

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Global.generated.h"

UCLASS()
class GRAVITYRUNUE_API AGlobal : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AGlobal();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	TSubclassOf<class ALaser> LaserClass;
	void SpawnLasers();

	UFUNCTION(BlueprintCallable, Category = "My Functions")
	void ShipDead();

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Global")
	int32 Score;

	float AccumTime;
	bool Alive;
	FTimerHandle timerHandle;
};
