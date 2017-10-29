﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZigZag
{
	/// <summary>
	/// This class contains all the skills of a shape 
	/// and handles the skills' execution
	/// </summary>
	public sealed class SkillManager : MonoBehaviour
	{
		#region Member Variables

		public GameObject currentShape;

		private List<Skill> m_skills;
		private Skill m_attack;
		private Skill m_ground;
		private Skill m_air;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets a value indicating whether any skill is active.
		/// </summary>
		public bool IsSkillActive
		{
			get
			{
				return (m_attack.IsActive || m_ground.IsActive || m_air.IsActive);
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Invoke the attack skill of the current shape.
		/// </summary>
		public void Attack()
		{
			if (m_attack != null)
			{
				m_attack.Activate ();
			}
		}

		/// <summary>
		/// Invoke the ground skill of the current shape.
		/// </summary>
		public void Ground()
		{
			if (m_ground != null)
			{
				m_ground.Activate ();
			}
		}

		/// <summary>
		/// Invoke the air skill of the current shape.
		/// </summary>
		public void Air()
		{
			if (m_air != null)
			{
				m_air.Activate ();
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Initialize member variables.
		/// </summary>
		private void Awake ()
		{
			m_skills = new List<Skill> (currentShape.GetComponents<Skill> ());

			m_attack = m_skills.Find (skill => skill.SkillType == SkillTypeEnum.Attack);
			m_ground = m_skills.Find (skill => skill.SkillType == SkillTypeEnum.Ground);
			m_air = m_skills.Find (skill => skill.SkillType == SkillTypeEnum.Air);
		}

		// TODO
		private void ChangeShapeHandler(object sender, Event args)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}