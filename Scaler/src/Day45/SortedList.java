package Day45;

public class SortedList {

	public static void main(String[] args) {
		int[] array = new int[] { 3, 4, 2, 8 };
		ListNode head = new ListNode(array[0]);
		var temp = head;
		for (int i = 1; i < array.length; i++) {
			ListNode new_node = new ListNode(array[i]);
			temp.next = new_node;
			if (i == 1) {
				head.next = temp;
			}
			temp = temp.next;
		}
		ListNode ans = sortList(head);
		printElement(ans);
	}
	public static ListNode sortList(ListNode A) {
		if (A == null || A.next == null) {
			return A;
		}

		ListNode mid = getMidListNode(A);
		ListNode first = A;
		ListNode second = mid.next;
		mid.next = null;
		first = sortList(first);
		second = sortList(second);

		return mergeListnode(first, second);

	}
	public static ListNode getMidListNode(ListNode m) {
		ListNode slow = m;
		ListNode fast = m;
		while (fast.next != null && fast.next.next != null) {
			slow = slow.next;
			fast = fast.next.next;
		}
		return slow;
	}
	public static ListNode mergeListnode(ListNode A, ListNode B) {
		if (A == null) {
			return B;
		}
		if (B == null) {
			return A;
		}

		ListNode head;
		if (A.val <= B.val) {
			head = A;
			A = A.next;
		} else {
			head = B;
			B = B.next;
		}
		ListNode temp = head;
		while (A != null && B != null) {
			if (A.val <= B.val) {
				temp.next = A;
				A = A.next;
			} else {
				temp.next = B;
				B = B.next;
			}
			temp = temp.next;
		}
		if (A == null) {
			temp.next = B;
		} else {
			temp.next = A;
		}

		return head;
	}
	public static void printElement(ListNode head) {
		ListNode temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
