// Fill out your copyright notice in the Description page of Project Settings.


#include "Global.h"

#include "UObject/ConstructorHelpers.h"
#include "Kismet/GameplayStatics.h"

// Sets default values
AGlobal::AGlobal()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	static ConstructorHelpers::FObjectFinder<UBlueprint>
		Laser(TEXT("Blueprint'/Game/LaserBP.LaserBP'"));
	if (Laser.Object) {
		LaserClass = (UClass*)Laser.Object->GeneratedClass;
	}

	Alive = true;
}

// Called when the game starts or when spawned
void AGlobal::BeginPlay()
{
	Super::BeginPlay();
	
	//GetWorldTimerManager().SetTimer(timerHandle, this, &AGlobal::SpawnLasers, 5.0f, true);
	Score = 0;
	AccumTime = 0.f;
}

// Called every frame
void AGlobal::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	if (Alive) {
		AccumTime += DeltaTime;
		Score = (int32)AccumTime;
	}
}

void AGlobal::SpawnLasers() {
	UWorld* const World = GetWorld();
	if (World) {
		for (int i = 0; i < 3; i++) {
			float random1 = (float)rand() / RAND_MAX;
			float random2 = (float)rand() / RAND_MAX;
			APlayerController* cam = UGameplayStatics::GetPlayerController(GetWorld(), 0);
			FVector actorLoc = cam->GetPawn()->GetActorLocation();
			FVector spawn = FVector(actorLoc[0], actorLoc[1], actorLoc[3] + 2000);
			ALaser* laser = World->SpawnActor<ALaser>(LaserClass, spawn, FRotator(0.f));
		}
	}
}

void AGlobal::ShipDead() {
	Alive = false;
}