using Hellmade.Sound;
public class SwordVfx : MobVfxBase {
	public override void OnSpawn() {
		base.OnSpawn();
		PoolManager.Instance.VFX.Sword.Spawn.Spawn(transform.position, transform.rotation);
		
		if (mobSound.hummingSound) EazySoundManager.PlaySound(mobSound.hummingSound, true, transform);
	}
	protected override void OnTakeDamage() {
		base.OnTakeDamage();
		PoolManager.Instance.VFX.VfxPool.Spawn(transform.position);
	}
	protected override void OnDead() {
		base.OnDead();
		PoolManager.Instance.VFX.Sword.Death.Spawn(transform.position, transform.rotation);
		EazySoundManager.PlaySound( mobSound.deathSound, false, transform );


	}
}
