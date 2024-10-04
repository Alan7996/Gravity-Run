// Fill out your copyright notice in the Description page of Project Settings.


#include "Laser.h"

// Sets default values
ALaser::ALaser()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	// Our root component will be a box that reacts to physics
	LaserBoxComponent =
		CreateDefaultSubobject<UBoxComponent>(TEXT("RootComponent"));
	RootComponent = LaserBoxComponent;
	LaserBoxComponent->InitBoxExtent(FVector(12.0f, 15.0f, 12.0f));
	LaserBoxComponent->SetCollisionProfileName(TEXT("BlockAllDynamic"));
	LaserBoxComponent->SetSimulatePhysics(true);
	LaserBoxComponent->SetEnableGravity(false);
	LaserBoxComponent->SetNotifyRigidBodyCollision(true);

	UPrimitiveComponent* RootComponentP = Cast<UPrimitiveComponent>(GetRootComponent());

	if (RootComponentP)
	{
		RootComponentP->SetPhysicsLinearVelocity(FVector(100.0f, 0.0f, 0.0f));
	}

}

// Called when the game starts or when spawned
void ALaser::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void ALaser::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}