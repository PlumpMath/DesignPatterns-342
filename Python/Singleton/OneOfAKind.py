import uuid

class NotThreadSafe(object):

	def __init__(self):
		self._ID = uuid.uuid4()

	__OneOfAKindInstance = None
	__ID = None

	@property
	def _Instance(self, value):
		if getattr(self, '__OneOfAKindInstance', None) is None:
			NotThreadSafe.__OneOfAKindInstance = self

		return self._InstanceVariable
	
	def GetID():
		return str(__ID)

	def GetInstance():
		if (__OneOfAKindInstance is None):
			__OneOfAKindInstance = __init__()
		return __OneOfAKindInstance